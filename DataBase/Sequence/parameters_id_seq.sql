﻿-- Sequence: public.parameters_id_seq

-- DROP SEQUENCE public.parameters_id_seq;

CREATE SEQUENCE public.parameters_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 11
  CACHE 1;
ALTER TABLE public.parameters_id_seq
  OWNER TO postgres;
