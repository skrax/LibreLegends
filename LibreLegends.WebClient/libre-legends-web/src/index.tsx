import ReactDOM from 'react-dom/client'
import {CardsApi} from "./clients/cardsApi";

function App() {
    const cardsApi = new CardsApi("https://localhost:7079")

    cardsApi.getCards().then(cards => console.log(cards));

    cardsApi.postCreature({
        cost: 1, health: 2, name: "Knight", strength: 1, description: "A noble warrior"

    }).then(x => console.log(x)).catch(err => console.log(err));

    return <h1>Hello from React!</h1>;
}

const root = ReactDOM.createRoot(document.getElementById('root')!);

root.render(<App/>);
