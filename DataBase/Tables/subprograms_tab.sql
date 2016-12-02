-- Table: public.subprograms

-- DROP TABLE public.subprograms;

CREATE TABLE public.subprograms
(
  id integer NOT NULL DEFAULT nextval('subprograms_id_seq'::regclass),
  name character varying(30) NOT NULL,
  description text,
  id_pump integer,
  id_vent integer,
  id_purge integer,
  id_power_supplay integer,
  id_gas integer,
  CONSTRAINT id_subprogram PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.subprograms
  OWNER TO postgres;
