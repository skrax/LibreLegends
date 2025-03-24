import { Creature, Spell } from "../models/card";
import { useContext, useEffect, useState } from "react";
import { CardsApi } from "../services/cardsApi";
import { ApiContext } from "../context";

const useCardState = function <T>(seedValue: T) {
  return function () {
    const [card, setCard] = useState<T>(seedValue);
    const [jsonPreview, setJsonPreview] = useState<string>("");

    useEffect(() => {
      setJsonPreview(JSON.stringify(card, null, 2));
    }, [card]);

    const updateCard = (field: keyof T, value: any) => {
      setCard((prev) => ({ ...prev, [field]: value }));
    };

    return { card, jsonPreview, updateCard };
  };
};

const useCreatureState = useCardState<Partial<Creature>>({});
const useSpellState = useCardState<Partial<Spell>>({});

const TextInput = ({
  label,
  placeholder,
  value,
  onChange,
}: {
  label: string;
  placeholder: string;
  value?: string;
  onChange: (value?: string) => void;
}) => (
  <>
    <label className="fieldset-label">{label}</label>
    <input
      type="text"
      className="input w-full"
      placeholder={placeholder}
      value={value}
      onChange={(e) => onChange(e.target.value || undefined)}
    />
  </>
);

const TextArea = ({
  label,
  placeholder,
  value,
  onChange,
}: {
  label: string;
  placeholder: string;
  value?: string;
  onChange: (value?: string) => void;
}) => (
  <>
    <label className="fieldset-label">{label}</label>
    <textarea
      className="textarea w-full"
      placeholder={placeholder}
      value={value}
      onChange={(e) => onChange(e.target.value || undefined)}
    />
  </>
);

const NumberInput = ({
  label,
  placeholder,
  value,
  onChange,
}: {
  label: string;
  placeholder: string;
  value?: number;
  onChange: (value?: number) => void;
}) => (
  <label className="join-item input w-full">
    <span className="label">{label}</span>
    <input
      type="number"
      className="input"
      min={0}
      placeholder={placeholder}
      value={value}
      onChange={(e) =>
        onChange(e.target.value === "" ? undefined : e.target.valueAsNumber)
      }
    />
  </label>
);

const CheckboxInput = ({
  label,
  checked,
  onChange,
}: {
  label: string;
  checked?: boolean;
  onChange: (checked?: boolean) => void;
}) => (
  <label className="fieldset-label">
    <input
      type="checkbox"
      className="checkbox"
      checked={checked}
      onChange={(e) => onChange(e.target.checked || undefined)}
    />
    {label}
  </label>
);

const CreatureForm = () => {
  const {
    card: creature,
    jsonPreview,
    updateCard: updateCreature,
  } = useCreatureState();
  
  const api = useContext(ApiContext);
  
  const onSubmit = () => {
    api.postCreature(creature as Creature).then();
  };

  return (
    <form onSubmit={onSubmit}>
      <fieldset className="fieldset max-w-lg bg-base-200 border border-base-300 p-4 rounded-box">
        <legend className="fieldset-legend">Creature</legend>

        <TextInput
          label="Name"
          placeholder="Armored Swordsman"
          value={creature.Name}
          onChange={(value) => updateCreature("Name", value)}
        />

        <TextArea
          label="Flavor Text"
          placeholder="Their shields are as steadfast as their loyalty."
          value={creature.FlavorText}
          onChange={(value) => updateCreature("FlavorText", value)}
        />

        <TextArea
          label="Description"
          placeholder="Defender"
          value={creature.Description}
          onChange={(value) => updateCreature("Description", value)}
        />

        <label className="fieldset-label">Stats</label>
        <div className="join">
          <NumberInput
            label="Cost"
            placeholder="3"
            value={creature.Cost}
            onChange={(value) => updateCreature("Cost", value)}
          />
          <NumberInput
            label="Strength"
            placeholder="3"
            value={creature.Strength}
            onChange={(value) => updateCreature("Strength", value)}
          />
          <NumberInput
            label="Health"
            placeholder="3"
            value={creature.Health}
            onChange={(value) => updateCreature("Health", value)}
          />
        </div>

        <fieldset className="fieldset p-4 bg-base-100 border border-base-300 rounded-box w-64">
          <legend className="fieldset-legend">Abilities</legend>

          <CheckboxInput
            label="Defender"
            checked={creature.Defender}
            onChange={(checked) => updateCreature("Defender", checked)}
          />

          <CheckboxInput
            label="Haste"
            checked={creature.Haste}
            onChange={(checked) => updateCreature("Haste", checked)}
          />

          <CheckboxInput
            label="Exposed"
            checked={creature.Exposed}
            onChange={(checked) => updateCreature("Exposed", checked)}
          />
        </fieldset>
      </fieldset>

      <fieldset className="fieldset max-w-lg bg-base-200 border border-base-300 p-4 rounded-box">
        <legend className="fieldset-legend">JSON Preview</legend>
        <pre>{jsonPreview}</pre>
      </fieldset>

      <fieldset className="fieldset max-w-lg mt-4">
        <button className="btn btn-primary">Submit</button>
      </fieldset>
    </form>
  );
};

const SpellForm = () => {
  const { card: spell, jsonPreview, updateCard: updateSpell } = useSpellState();

  const onSubmit = () => {};

  return (
    <form onSubmit={onSubmit}>
      <fieldset className="fieldset max-w-lg bg-base-200 border border-base-300 p-4 rounded-box">
        <legend className="fieldset-legend">Spell</legend>

        <TextInput
          label="Name"
          placeholder="Healing Light"
          value={spell.Name}
          onChange={(value) => updateSpell("Name", value)}
        />

        <TextArea
          label="Flavor Text"
          placeholder="A gentle touch, a swift recovery."
          value={spell.FlavorText}
          onChange={(value) => updateSpell("FlavorText", value)}
        />

        <TextArea
          label="Description"
          placeholder="Restore 4 health to a friendly creature or hero."
          value={spell.Description}
          onChange={(value) => updateSpell("Description", value)}
        />

        <label className="fieldset-label">Stats</label>
        <div className="join">
          <NumberInput
            label="Cost"
            placeholder="2"
            value={spell.Cost}
            onChange={(value) => updateSpell("Cost", value)}
          />
        </div>
      </fieldset>

      <fieldset className="fieldset max-w-lg bg-base-200 border border-base-300 p-4 rounded-box">
        <legend className="fieldset-legend">JSON Preview</legend>
        <pre>{jsonPreview}</pre>
      </fieldset>

      <fieldset className="fieldset max-w-lg mt-4">
        <button className="btn btn-primary">Submit</button>
      </fieldset>
    </form>
  );
};

export default function CardCreator() {
  return (
    <div className="tabs tabs-lift">
      <input
        type="radio"
        name="my_tabs_3"
        className="tab"
        aria-label="Creature"
        defaultChecked
      />
      <div className="tab-content bg-base-100 border-base-300 p-6">
        <CreatureForm />
      </div>

      <input type="radio" name="my_tabs_3" className="tab" aria-label="Spell" />
      <div className="tab-content bg-base-100 border-base-300 p-6">
        <SpellForm />
      </div>
    </div>
  );
}
