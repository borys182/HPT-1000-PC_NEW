﻿-- Sequence: public.priviliges_id_seq

-- DROP SEQUENCE public.priviliges_id_seq;

CREATE SEQUENCE public.priviliges_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 3
  CACHE 1;
ALTER TABLE public.priviliges_id_seq
  OWNER TO postgres;
