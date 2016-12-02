﻿-- Sequence: public.gas_types_id_seq

-- DROP SEQUENCE public.gas_types_id_seq;

CREATE SEQUENCE public.gas_types_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 10
  CACHE 1;
ALTER TABLE public.gas_types_id_seq
  OWNER TO postgres;
