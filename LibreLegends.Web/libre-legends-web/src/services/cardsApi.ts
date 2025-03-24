import { ApiClientBase } from "./apiClientBase";
import { UUID } from "node:crypto";
import { Creature, Spell } from "../models/card";

export class CardsApi extends ApiClientBase {
  constructor(baseUrl: string) {
    super(baseUrl);
  }

  public getCards() {
    return this.get<{}>("/cards");
  }

  public getCard(id: UUID) {
    return this.get<{} | undefined>(`/cards/${id}`);
  }

  public getCreatures() {
    return this.get<{}>("/cards/creatures");
  }


  public postCreature(creature: Creature) {
    return this.post<{}>("/cards/creatures", creature);
  }

  public putCreature(creature: Creature) {
    return this.put<{}>("/cards/creatures", {});
  }

  public getSpells() {
    return this.get<{}>("/cards/spells");
  }

  public postSpell(spell: Spell) {
    return this.post<{}>("/cards/spells", {});
  }

  public putSpell(spell: Spell) {
    return this.put<{}>("/cards/spells", {});
  }

  public deleteCards() {
    return this.delete("/cards");
  }

  public deleteCard(id: UUID) {
    return this.delete(`/cards/${id}`);
  }

}