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

CREATE ROLE admin_role LOGIN PASSWORD 'admin123';
CREATE ROLE customer_role LOGIN PASSWORD 'customer123';
CREATE ROLE freelancer_role LOGIN PASSWORD 'free123';


GRANT ALL PRIVILEGES
ON ALL TABLES IN SCHEMA public
TO admin_role;

GRANT SELECT, INSERT, UPDATE, DELETE
ON vacancies
TO customer_role;

GRANT SELECT
ON responses
TO customer_role;


GRANT SELECT, INSERT, UPDATE, DELETE
ON responses
TO freelancer_role;

GRANT SELECT, INSERT, UPDATE, DELETE
ON feedbacks
TO freelancer_role;


GRANT USAGE, SELECT
ON ALL SEQUENCES IN SCHEMA public
TO admin_role;

GRANT USAGE, SELECT
ON ALL SEQUENCES IN SCHEMA public
TO customer_role;

GRANT USAGE, SELECT
ON ALL SEQUENCES IN SCHEMA public
TO freelancer_role;


ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT USAGE, SELECT ON SEQUENCES
TO admin_role;

ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT USAGE, SELECT ON SEQUENCES
TO customer_role;

ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT USAGE, SELECT ON SEQUENCES
TO freelancer_role;


INSERT INTO roles (name) VALUES
('Администратор'),
('Заказчик'),
('Фрилансер');

INSERT INTO users (
    name,
    surname,
    email,
    password,
    profile_description,
    role,
    role_id
) VALUES
(
    'Админ',
    '',
    'postgres',
    '1',
    'Администратор',
    'Администратор',
    1
),
(
    'Иван',
    'Петров',
    'ivan.petrov@mail.ru',
    'pass123',
    'Backend-разработчик на Python и PostgreSQL',
    'Фрилансер',
    3
),
(
    'Анна',
    'Сидорова',
    'anna.sidorova@mail.ru',
    'pass456',
    'Заказчик IT-проектов',
    'Заказчик',
    2
),
(
    'Дмитрий',
    'Кузнецов',
    'dmitry.k@mail.ru',
    'pass789',
    'Fullstack-разработчик',
    'Фрилансер',
    3
),
(
    'Елена',
    'Орлова',
    'elena.orlova@mail.ru',
    'adminpass',
    'Администратор платформы',
    'Администратор',
    1
);


INSERT INTO tags (name) VALUES
('Python'),
('PostgreSQL'),
('Web-разработка'),
('JavaScript'),
('Дизайн'),
('Frontend');

INSERT INTO vacancies (
    title,
    description,
    budget,
    deadline,
    author_id
) VALUES
(
    'Разработка интернет-магазина',
    'Требуется разработка интернет-магазина на Django.',
    120000.00,
    '2026-06-20',
    13
),
(
    'Создание landing page',
    'Необходимо сверстать современный landing page.',
    35000.00,
    '2026-05-30',
    15
),
(
    'Разработка REST API',
    'Создание REST API для мобильного приложения.',
    80000.00,
    '2026-06-10',
    14
);


INSERT INTO vacancy_tags (vacancy_id, tag_id) VALUES
(11, 1),
(12, 2),
(13, 3),
(11, 4),
(12, 6),
(13, 5),
(11, 1),
(12, 2);


INSERT INTO news (
    title,
    anons,
    content,
    author_id
) VALUES
(
    'Запуск новой версии платформы',
    'Обновление функционала биржи',
    'На платформе добавлена система откликов и улучшен поиск вакансий.',
    16
),
(
    'Технические работы',
    'Плановое обслуживание серверов',
    '15 мая будут проводиться технические работы с 02:00 до 04:00.',
    21
);


INSERT INTO feedbacks (
    message,
    title,
    author_id
) VALUES
(
    'Очень удобная платформа для поиска заказов.',
    'Отличный сервис',
    13
),
(
    'Хотелось бы добавить больше фильтров поиска.',
    'Предложение по улучшению',
    15
);


INSERT INTO responses (
    vacancy_id,
    user_id,
    message
) VALUES
(
    1,
    14,
    'Готов выполнить проект. Есть опыт разработки на Django.'
),
(
    2,
    14,
    'Могу быстро сверстать адаптивный landing page.'
),
(
    3,
    14,
    'Имею опыт создания REST API и работы с PostgreSQL.'
);