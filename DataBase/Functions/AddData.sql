-- Function: public."AddData"(integer, real, character varying, timestamp without time zone)

-- DROP FUNCTION public."AddData"(integer, real, character varying, timestamp without time zone);

CREATE OR REPLACE FUNCTION public."AddData"(
    para_id integer,
    value_ real,
    unit_ character varying,
    date_ timestamp without time zone)
  RETURNS integer AS
$BODY$DECLARE
	id_data		integer := 0;
	id_sesion 	integer := 0;
	
BEGIN
	--Dodaj rekord danych
	insert into data(id_parameter,value,unit,date)values(para_id,value_,unit_,date_)returning id into id_data;
	
	--Aktualizuj czas trwania sesji. Odczytaj rekord aktualnej sesji i aktualizuj czas end
	select current_sesion_id from current_sesion into id_sesion;

	update sesions set date_end = date_ where id = id_sesion;

	RETURN id_data;

	EXCEPTION
		WHEN OTHERS THEN
			RAISE;
END;$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public."AddData"(integer, real, character varying, timestamp without time zone)
  OWNER TO postgres;
