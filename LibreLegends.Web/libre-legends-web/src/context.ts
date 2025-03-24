import { createContext } from "react";
import { CardsApi } from "./services/cardsApi";

export const ApiContext = createContext(new CardsApi("https://localhost:7079"));
