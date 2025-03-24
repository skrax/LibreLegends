-- Card Types Table
CREATE TABLE IF NOT EXISTS public.card_types
(
    id          serial PRIMARY KEY,
    name        varchar(50) NOT NULL UNIQUE,
    description text,
    created_at  timestamptz NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Cards Table
CREATE TABLE IF NOT EXISTS public.cards
(
    id           uuid                  DEFAULT gen_random_uuid() PRIMARY KEY,
    name         varchar(100) NOT NULL,
    flavor_text  text,
    description  text,
    card_type_id integer      NOT NULL REFERENCES public.card_types (id),
    cost         integer,
    strength     integer,
    health       integer,
    defender     boolean,
    haste        boolean,
    exposed      boolean,
    behavior     jsonb,
    created_at   timestamptz  NOT NULL DEFAULT CURRENT_TIMESTAMP,

    -- Creature constraint
    CONSTRAINT creature CHECK (
        card_type_id != 1 OR (
            cost IS NOT NULL AND
            strength IS NOT NULL AND
            health IS NOT NULL AND
            defender IS NOT NULL AND
            haste IS NOT NULL AND
            exposed IS NOT NULL
            )
        ),

    -- Spell constraint
    CONSTRAINT spell CHECK (
        card_type_id != 2 OR (
            cost IS NOT NULL AND
            behavior IS NOT NULL AND
            strength IS NULL AND
            health IS NULL AND
            defender IS NULL AND
            haste IS NULL AND
            exposed IS NULL
            )
        )
);

-- Initial Card Types
INSERT INTO public.card_types(id, name, description)
VALUES (1, 'Creature', 'Cards which an attack and defend'),
       (2, 'Spell', 'Cards which have an immediate one-time effect');