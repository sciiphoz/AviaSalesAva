--
-- PostgreSQL database dump
--

\restrict VmVSN9VKV0WSzqSaba5UG65baOIIVDanWvkP8Z32c93xa36Sd0DvUVO9OwF6HTF

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2025-10-27 14:35:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 5037 (class 0 OID 17428)
-- Dependencies: 224
-- Data for Name: Promo; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Promo" ("ID_Promo", "Discount") VALUES (1, 21);
INSERT INTO public."Promo" ("ID_Promo", "Discount") VALUES (2, 50);
INSERT INTO public."Promo" ("ID_Promo", "Discount") VALUES (3, 75);


--
-- TOC entry 5035 (class 0 OID 17418)
-- Dependencies: 222
-- Data for Name: Flight; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Flight" ("ID_Flight", "Airline", "Aircraft", "DepartureCity", "ArrivalCity", "DepartureTime", "ArrivalTime", "Price", "Class", "SeatNumber", "Status", "ID_Promo") VALUES (2, 'airline4', 'aircraft7', 'city2', 'city6', '2025-05-12', '2025-05-13', 500, 'economy', 120, 'scheduled', NULL);
INSERT INTO public."Flight" ("ID_Flight", "Airline", "Aircraft", "DepartureCity", "ArrivalCity", "DepartureTime", "ArrivalTime", "Price", "Class", "SeatNumber", "Status", "ID_Promo") VALUES (1, 'airline2', 'aircraft3', 'city1', 'city2', '2025-10-24', '2025-10-25', 300, 'economy', 40, 'scheduled', 3);
INSERT INTO public."Flight" ("ID_Flight", "Airline", "Aircraft", "DepartureCity", "ArrivalCity", "DepartureTime", "ArrivalTime", "Price", "Class", "SeatNumber", "Status", "ID_Promo") VALUES (3, 'airline3', 'aircraft1', 'city5', 'city1', '2025-01-26', '2025-01-27', 1000, 'economy', 80, 'scheduled', 1);


--
-- TOC entry 5039 (class 0 OID 17436)
-- Dependencies: 226
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Role" ("ID_Role", "Title") VALUES (1, 'passenger');
INSERT INTO public."Role" ("ID_Role", "Title") VALUES (3, 'admin');
INSERT INTO public."Role" ("ID_Role", "Title") VALUES (2, 'manager');


--
-- TOC entry 5041 (class 0 OID 17444)
-- Dependencies: 228
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."User" ("ID_User", "Name", "Email", "Password", "ID_Role") VALUES (1, 'user', 'user@gmail.com', '123123123', 1);
INSERT INTO public."User" ("ID_User", "Name", "Email", "Password", "ID_Role") VALUES (2, 'manager', 'manager@gmail.com', '123123123', 2);
INSERT INTO public."User" ("ID_User", "Name", "Email", "Password", "ID_Role") VALUES (3, 'admin', 'admin@gmail.com', '123123123', 3);



--
-- TOC entry 5033 (class 0 OID 17410)
-- Dependencies: 220
-- Data for Name: Booking; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Booking" ("ID_Booking", "ID_User", "ID_Flight") VALUES (1, 1, 2);


--
-- TOC entry 5047 (class 0 OID 0)
-- Dependencies: 219
-- Name: Booking_ID_Booking_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Booking_ID_Booking_seq"', 1, false);


--
-- TOC entry 5048 (class 0 OID 0)
-- Dependencies: 221
-- Name: Flight_ID_Flight_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Flight_ID_Flight_seq"', 1, false);


--
-- TOC entry 5049 (class 0 OID 0)
-- Dependencies: 223
-- Name: Promo_ID_Promo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Promo_ID_Promo_seq"', 1, false);


--
-- TOC entry 5050 (class 0 OID 0)
-- Dependencies: 225
-- Name: Role_ID_Role_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Role_ID_Role_seq"', 1, false);


--
-- TOC entry 5051 (class 0 OID 0)
-- Dependencies: 227
-- Name: User_ID_User_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."User_ID_User_seq"', 1, false);


-- Completed on 2025-10-27 14:35:38

--
-- PostgreSQL database dump complete
--

\unrestrict VmVSN9VKV0WSzqSaba5UG65baOIIVDanWvkP8Z32c93xa36Sd0DvUVO9OwF6HTF

