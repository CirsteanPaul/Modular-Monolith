\c app

DO $$
    BEGIN
        CREATE SCHEMA app AUTHORIZATION paul;
        RAISE NOTICE 'Schema app created';
    END;
$$;


