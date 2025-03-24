export type Creature = {
  Name: string;
  FlavorText?: string;
  Description?: string;
  Cost: number;
  Strength: number;
  Health: number;
  Defender?: boolean;
  Haste?: boolean;
  Exposed?: boolean;
  BehaviorJson?: string;
}

export type Spell = {
  Name: string;
  FlavorText?: string;
  Description: string;
  Cost: number;
  BehaviorJson: string;
}
