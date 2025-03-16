import { Creature } from "../models/card";
import { useEffect, useState } from "react";

const useCreatureForm = () => {
  const [creature, setCreature] = useState<Creature>(new Creature());
  const [jsonPreview, setJsonPreview] = useState<string>("");

  useEffect(() => {
    setJsonPreview(JSON.stringify(creature, null, 2));
  }, [creature]);

  const updateCreature = (field: keyof Creature, value: any) => {
    setCreature((prev) => ({ ...prev, [field]: value }));
  };

  return { creature, jsonPreview, updateCreature };
};

const TextInput = ({
  label,
  placeholder,
  value,
  onChange,
}: {
  label: string;
  placeholder: string;
  value: string;
  onChange: (value: string) => void;
}) => (
  <>
    <label className="fieldset-label">{label}</label>
    <input
      type="text"
      className="input w-full"
      placeholder={placeholder}
      value={value}
      onChange={(e) => onChange(e.target.value)}
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
  value: string;
  onChange: (value: string) => void;
}) => (
  <>
    <label className="fieldset-label">{label}</label>
    <textarea
      className="textarea w-full"
      placeholder={placeholder}
      value={value}
      onChange={(e) => onChange(e.target.value)}
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
  value: number;
  onChange: (value: number) => void;
}) => (
  <label className="join-item input">
    <span className="label">{label}</span>
    <input
      type="number"
      className="input"
      placeholder={placeholder}
      value={value || ""}
      onChange={(e) => onChange(parseInt(e.target.value) || 0)}
    />
  </label>
);

const CheckboxInput = ({
  label,
  checked,
  onChange,
}: {
  label: string;
  checked: boolean;
  onChange: (checked: boolean) => void;
}) => (
  <label className="fieldset-label">
    <input
      type="checkbox"
      className="checkbox"
      checked={checked}
      onChange={(e) => onChange(e.target.checked)}
    />
    {label}
  </label>
);

export default function CardCreator() {
  const { creature, jsonPreview, updateCreature } = useCreatureForm();

  return (
    <div className="w-full max-w-4xl mx-auto p-4 bg-white rounded-lg shadow">
      <fieldset className="fieldset max-w-lg bg-base-200 border border-base-300 p-4 rounded-box">
        <legend className="fieldset-legend">Creature</legend>

        <TextInput
          label="Name"
          placeholder="Armored Swordsman"
          value={creature.Name || ""}
          onChange={(value) => updateCreature("Name", value)}
        />

        <TextArea
          label="Flavor Text"
          placeholder="Their shields are as steadfast as their loyalty."
          value={creature.FlavorText || ""}
          onChange={(value) => updateCreature("FlavorText", value)}
        />

        <TextArea
          label="Description"
          placeholder="Defender"
          value={creature.Description || ""}
          onChange={(value) => updateCreature("Description", value)}
        />

        <label className="fieldset-label">Stats</label>
        <div className="join">
          <NumberInput
            label="Cost"
            placeholder="3"
            value={creature.Cost || 0}
            onChange={(value) => updateCreature("Cost", value)}
          />
          <NumberInput
            label="Strength"
            placeholder="3"
            value={creature.Strength || 0}
            onChange={(value) => updateCreature("Strength", value)}
          />
          <NumberInput
            label="Health"
            placeholder="3"
            value={creature.Health || 0}
            onChange={(value) => updateCreature("Health", value)}
          />
        </div>

        <fieldset className="fieldset p-4 bg-base-100 border border-base-300 rounded-box w-64">
          <legend className="fieldset-legend">Abilities</legend>

          <CheckboxInput
            label="Defender"
            checked={creature.Defender || false}
            onChange={(checked) => updateCreature("Defender", checked)}
          />

          <CheckboxInput
            label="Haste"
            checked={creature.Haste || false}
            onChange={(checked) => updateCreature("Haste", checked)}
          />

          <CheckboxInput
            label="Exposed"
            checked={creature.Exposed || false}
            onChange={(checked) => updateCreature("Exposed", checked)}
          />
        </fieldset>
      </fieldset>

      <fieldset className="fieldset max-w-lg bg-base-200 border border-base-300 p-4 rounded-box">
        <legend className="fieldset-legend">JSON Preview</legend>
        <pre>{jsonPreview}</pre>
      </fieldset>
    </div>
  );
}
