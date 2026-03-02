import { useEffect, useState } from "react";

type Game = {
  id: number;
  title: string;
  genre: string;
  price: number;
  releaseDate: string;
};

function GameCollection() {
  const [games, setGames] = useState<Game[]>([]);

  useEffect(() => {
    fetch("http://localhost:5023/games").then((gamePackage) =>
      gamePackage.json().then((gamesList) => setGames(gamesList)),
    );
  }, []);

  async function handleDelete(id: number) {
    await fetch(`http://localhost:5023/games/${id}`, {
      method: "DELETE",
    });
  }

  return (
    <ul>
      {games.map((game) => (
        <li key={game.id}>
          <h3>{game.title}</h3>
          <p>
            A {game.genre} style game, costing {game.price}. Released{" "}
            {game.releaseDate}
          </p>
          {/* <button onClick={handleEdit}>Edit</button> */}
          <button onClick={() => handleDelete(game.id)}>Delete</button>
        </li>
      ))}
    </ul>
  );
}

export default GameCollection;
