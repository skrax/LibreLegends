CREATE TABLE IF NOT EXISTS public.card_types
(
    id serial,
    name character varying(50) NOT NULL,
    description text,
    created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
                             PRIMARY KEY (id),
    UNIQUE (name)
);

CREATE TABLE IF NOT EXISTS public.cards
(
    id uuid DEFAULT gen_random_uuid(),
    name character varying(100) NOT NULL,
    description text,
    card_type_id integer NOT NULL,
    cost integer,
    strength integer,
    health integer,
    abilities jsonb,
    created_at timestamp with time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (card_type_id)
        REFERENCES public.card_types (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT creature CHECK (card_type_id != 1 OR (cost IS NOT NULL AND strength IS NOT NULL AND health IS NOT NULL)) NOT VALID,
    CONSTRAINT spell CHECK (card_type_id != 2 OR (cost IS NOT NULL AND abilities IS NOT NULL)) NOT VALID
);

INSERT INTO public.card_types(id, name, description)
VALUES(1, 'Creature', 'Cards which an attack and defend'),
      (2, 'Spell', 'Cards which have an immediate one-time effect');
