SELECT rolname FROM pg_roles;
DROP ROLE admin_role;
DROP ROLE customer_role;
DROP ROLE freelancer_role;

DROP SCHEMA public CASCADE;
CREATE SCHEMA public;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO public;



CREATE TABLE roles (
role_id SERIAL PRIMARY KEY,
role_name VARCHAR(50) NOT NULL UNIQUE
);

ALTER TABLE roles
RENAME COLUMN role_id TO id;

ALTER TABLE roles
RENAME COLUMN role_name TO name;

-- Начальные роли
INSERT INTO roles (name)
VALUES
('Администратор'),
('Пользователь');


CREATE TABLE users (
user_id SERIAL PRIMARY KEY,
first_name VARCHAR(50) NOT NULL,
last_name VARCHAR(50) NOT NULL,
email VARCHAR(100) NOT NULL UNIQUE,
password VARCHAR(255) NOT NULL,
registration_date DATE NOT NULL DEFAULT CURRENT_DATE,
profile_description TEXT,
role_id INTEGER NOT NULL,

ALTER TABLE users
RENAME COLUMN user_id TO id;

ALTER TABLE users
RENAME COLUMN first_name TO name;

ALTER TABLE users
RENAME COLUMN last_name TO surname;

ALTER TABLE users 
ADD COLUMN avatar_path VARCHAR(255);


CONSTRAINT fk_users_role
    FOREIGN KEY (role_id)
    REFERENCES roles(role_id)
    ON DELETE RESTRICT
    ON UPDATE CASCADE
);

CREATE TABLE vacancies (
vacancy_id SERIAL PRIMARY KEY,
title VARCHAR(150) NOT NULL,
description TEXT NOT NULL,
budget DECIMAL(10,2) NOT NULL CHECK (budget >= 0),
deadline DATE NOT NULL,
publish_date DATE NOT NULL DEFAULT CURRENT_DATE,
user_id INTEGER NOT NULL,

ALTER TABLE vacancies
RENAME COLUMN vacancy_id TO id;

ALTER TABLE vacancies
RENAME COLUMN publish_date TO publication_date;

ALTER TABLE vacancies
RENAME COLUMN user_id TO author_id;


CONSTRAINT fk_vacancy_user
    FOREIGN KEY (user_id)
    REFERENCES users(user_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);


CREATE TABLE tags (
tag_id SERIAL PRIMARY KEY,
tag_name VARCHAR(100) NOT NULL UNIQUE
);

ALTER TABLE tags
RENAME COLUMN tag_id TO id;

ALTER TABLE tags
RENAME COLUMN tag_name TO name;

CREATE TABLE vacancy_tags (
vacancy_id INTEGER NOT NULL,
tag_id INTEGER NOT NULL,

PRIMARY KEY (vacancy_id, tag_id),

CONSTRAINT fk_vt_vacancy
    FOREIGN KEY (vacancy_id)
    REFERENCES vacancies(vacancy_id)
    ON DELETE CASCADE,

CONSTRAINT fk_vt_tag
    FOREIGN KEY (tag_id)
    REFERENCES tags(tag_id)
    ON DELETE CASCADE
);

CREATE TABLE responses (
response_id SERIAL PRIMARY KEY,
vacancy_id INTEGER NOT NULL,
user_id INTEGER NOT NULL,
message TEXT NOT NULL,
response_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

ALTER TABLE responses
RENAME COLUMN response_id TO id;

ALTER TABLE responses
RENAME COLUMN response_date TO created_at;

CONSTRAINT fk_response_vacancy
    FOREIGN KEY (vacancy_id)
    REFERENCES vacancies(vacancy_id)
    ON DELETE CASCADE,

CONSTRAINT fk_response_user
    FOREIGN KEY (user_id)
    REFERENCES users(user_id)
    ON DELETE CASCADE
);

CREATE TABLE news (
news_id SERIAL PRIMARY KEY,
title VARCHAR(200) NOT NULL,
announcement TEXT NOT NULL,
content TEXT NOT NULL,
created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
author_id INTEGER NOT NULL,

ALTER TABLE news
RENAME COLUMN news_id TO id;

ALTER TABLE news
RENAME COLUMN announcement TO anons;

ALTER TABLE news
RENAME COLUMN created_at TO creation_date;

CONSTRAINT fk_news_author
    FOREIGN KEY (author_id)
    REFERENCES users(user_id)
    ON DELETE CASCADE
);

CREATE TABLE feedback (
feedback_id SERIAL PRIMARY KEY,
title VARCHAR(150) NOT NULL,
message TEXT NOT NULL,
created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
user_id INTEGER NOT NULL,

ALTER TABLE feedback
RENAME TO feedbacks;

ALTER TABLE feedbacks
RENAME COLUMN feedback_id TO id;

ALTER TABLE feedbacks
RENAME COLUMN user_id TO author_id;

ALTER TABLE feedbacks
RENAME COLUMN created_at TO send_date;

CONSTRAINT fk_feedback_user
    FOREIGN KEY (user_id)
    REFERENCES users(user_id)
    ON DELETE CASCADE
);

INSERT INTO tags (tag_name)
VALUES
('Web Development'),
('Frontend'),
('Backend'),
('JavaScript'),
('Python'),
('Java'),
('PostgreSQL'),
('UI/UX Design');


CREATE ROLE admin_role
LOGIN
PASSWORD 'admin123';

CREATE ROLE user_role
LOGIN
PASSWORD 'user123';


GRANT ALL PRIVILEGES
ON DATABASE freelance_db
TO admin_role;

GRANT CONNECT
ON DATABASE freelance_db
TO user_role;


GRANT ALL PRIVILEGES
ON ALL TABLES IN SCHEMA public
TO admin_role;

GRANT ALL PRIVILEGES
ON ALL SEQUENCES IN SCHEMA public
TO admin_role;

GRANT SELECT, INSERT, UPDATE, DELETE
ON ALL TABLES IN SCHEMA public
TO user_role;


ALTER SYSTEM SET timezone = 'Europe/Moscow';
SELECT pg_reload_conf();


CREATE TABLE report_templates
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    header TEXT,
    footer TEXT,
    show_logo BOOLEAN,
    show_date BOOLEAN
);