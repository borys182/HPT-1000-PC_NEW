﻿-- Function: public."ModifySubprogramStages_1"(integer, time without time zone, time without time zone, time without time zone, real, real, integer, real, time without time zone)

-- DROP FUNCTION public."ModifySubprogramStages_1"(integer, time without time zone, time without time zone, time without time zone, real, real, integer, real, time without time zone);

CREATE OR REPLACE FUNCTION public."ModifySubprogramStages_1"(
    id_subprogram integer,
    time_vent time without time zone,
    time_purge time without time zone,
    time_pump time without time zone,
    setpoint_pressure_pump real,
    setpoint_power_supply real,
    mode_power_supply integer,
    max_devation_power_supply real,
    time_duration_power_supply time without time zone)
  RETURNS integer AS
$BODY$
  DECLARE
	res 		integer := 0;
	pump_id 	integer := 0;
	vent_id 	integer := 0;
	purge_id 	integer := 0;
	power_supply_id	integer := 0;
	
  BEGIN

	select id_pump 		into pump_id 	     from subprograms where subprograms.id = id_subprogram; 
	select id_vent 		into vent_id 	     from subprograms where subprograms.id = id_subprogram; 
	select id_purge 	into purge_id 	     from subprograms where subprograms.id = id_subprogram; 
	select id_power_supplay into power_supply_id from subprograms where subprograms.id = id_subprogram; 

	update stages_pump set max_time_pump = time_pump, setpoint_pressure = setpoint_pressure_pump where stages_pump.id = pump_id;
	update stages_vent set vent_time = time_vent where stages_vent.id = vent_id;
	update stages_purge set time = time_purge where stages_purge.id = purge_id;
	update stages_power_supply set setpoint = setpoint_power_supply ,mode = mode_power_supply, duration_time = time_duration_power_supply, max_devation = max_devation_power_supply where stages_power_supply.id = power_supply_id;

	RETURN res;
	EXCEPTION
		WHEN UNIQUE_VIOLATION THEN
			RAISE 'Program name alredy exist';
		WHEN NOT_NULL_VIOLATION THEN
			RAISE 'Required fields are not filled';
		WHEN OTHERS THEN
			RAISE;
  END;$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public."ModifySubprogramStages_1"(integer, time without time zone, time without time zone, time without time zone, real, real, integer, real, time without time zone)
  OWNER TO postgres;
