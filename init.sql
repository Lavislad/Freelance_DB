-- Database: postgres

-- DROP DATABASE IF EXISTS postgres;

-- CREATE DATABASE postgres
--     WITH
--     OWNER = postgres
--     ENCODING = 'UTF8'
--     LC_COLLATE = 'Russian_Russia.1251'
--     LC_CTYPE = 'Russian_Russia.1251'
--     LOCALE_PROVIDER = 'libc'
--     TABLESPACE = pg_default
--     CONNECTION LIMIT = -1
--     IS_TEMPLATE = False;

-- COMMENT ON DATABASE postgres
--     IS 'default administrative connection database';

CREATE TABLE responses (
    id SERIAL PRIMARY KEY,
    vacancy_id INTEGER REFERENCES vacancies(id) ON DELETE CASCADE,
    user_id INTEGER REFERENCES users(id) ON DELETE CASCADE,
    message TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE roles (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    surname VARCHAR(100),
    email VARCHAR(255) UNIQUE NOT NULL,
    password TEXT NOT NULL,
    registration_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    profile_description TEXT,
    role VARCHAR(50) NOT NULL
);

ALTER TABLE users
ADD COLUMN role_id INTEGER REFERENCES roles(id);

CREATE TABLE vacancies (
    id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    budget NUMERIC(10,2),
    deadline DATE,
    publication_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    author_id INTEGER REFERENCES users(id) ON DELETE CASCADE
);

CREATE TABLE tags (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE vacancy_tags (
    vacancy_id INTEGER REFERENCES vacancies(id) ON DELETE CASCADE,
    tag_id INTEGER REFERENCES tags(id) ON DELETE CASCADE,

    PRIMARY KEY (vacancy_id, tag_id)
);


CREATE TABLE news (
    id SERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
	anons varchar(255) not NULL,
    content TEXT NOT NULL,
    creation_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE feedbacks (
    id SERIAL PRIMARY KEY,
    message TEXT NOT NULL,
	title VARCHAR(255) NOT NULL,
    send_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    author_id INTEGER REFERENCES users(id) ON DELETE CASCADE
);

ALTER TABLE news
ADD COLUMN author_id INTEGER REFERENCES users(id) ON DELETE SET NULL;



