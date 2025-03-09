ALTER TABLE IF EXISTS public.cards DROP CONSTRAINT IF EXISTS spell;

ALTER TABLE IF EXISTS public.cards
    ADD CONSTRAINT spell CHECK (card_type_id <> 2 OR cost IS NOT NULL AND abilities IS NOT NULL AND strength IS NULL AND health IS NULL)
    NOT VALID;