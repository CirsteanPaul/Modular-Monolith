DO $$
BEGIN
CREATE SCHEMA administration AUTHORIZATION paul;
RAISE NOTICE 'Create administration schema';
END;
$$;
