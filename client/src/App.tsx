import { useEffect, useState } from "react";

type Game = {
  id: number;
  title: string;
  genre: string;
  price: number;
  releaseDate: string;
};

function App() {
  const [games, setGames] = useState<Game[]>([]);

  useEffect(() => {
    fetch("http://localhost:5023/games")
      .then((pckg) => pckg.json())
      .then((games) => setGames(games));
  }, []);

  return (
    <div>
      <ul>
        {games.map((x) => (
          <li key={x.id}>
            <h3>{x.title}</h3>
            <p>{`Genre: ${x.genre}, Price: ${x.price}, released ${x.releaseDate}`}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
