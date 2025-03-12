import {ApiClientBase} from "./apiClientBase";
import {UUID} from "node:crypto";

export class CardsApi extends ApiClientBase {
    constructor(baseUrl: string) {
        super(baseUrl);
    }
    public getCards() {
        return this.get<{}>("/cards")
    }

    public getCard(id: UUID) {
        return this.get<{} | undefined>(`/cards/${id}`)
    }

    public getCreatures() {
        return this.get<{}>("/cards/creatures");
    }

    public postCreature(creature: {
        name: string;
        description?: string;
        cost: number;
        strength: number;
        health: number;
    }) {
        return this.post<{}>("/cards/creatures", creature);
    }

    public putCreature() {
        return this.put<{}>("/cards/creatures", {});
    }

    public getSpells() {
        return this.get<{}>("/cards/spells");
    }

    public postSpell() {
        return this.post<{}>("/cards/spells", {});
    }

    public putSpell() {
        return this.put<{}>("/cards/spells", {});
    }
    
    public deleteCards(){
        return this.delete("/cards");
    }

    public deleteCard(id: UUID) {
        return this.delete(`/cards/${id}`)
    }

}