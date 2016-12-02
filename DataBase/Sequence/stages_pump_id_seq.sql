﻿-- Sequence: public.stages_pump_id_seq

-- DROP SEQUENCE public.stages_pump_id_seq;

CREATE SEQUENCE public.stages_pump_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 20
  CACHE 1;
ALTER TABLE public.stages_pump_id_seq
  OWNER TO postgres;
