-- Table: public.sesions

-- DROP TABLE public.sesions;

CREATE TABLE public.sesions
(
  id integer NOT NULL DEFAULT nextval('sesions_id_seq'::regclass),
  date_start timestamp without time zone NOT NULL,
  date_end timestamp without time zone NOT NULL,
  CONSTRAINT sesions_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.sesions
  OWNER TO postgres;
