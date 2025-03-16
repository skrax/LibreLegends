import Home from "./views/Home";
import { BrowserRouter, Route, Routes } from "react-router";
import CardCreator from "./views/CardCreator";
import Layout from "./views/Layout";

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="card-creator" element={<CardCreator />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
