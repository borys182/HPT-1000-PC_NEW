﻿-- Sequence: public.programs_id_seq

-- DROP SEQUENCE public.programs_id_seq;

CREATE SEQUENCE public.programs_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 4
  CACHE 1;
ALTER TABLE public.programs_id_seq
  OWNER TO postgres;
