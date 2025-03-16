import React from "react";
import { Outlet } from "react-router";

export default function Layout() {
  return (
    <div className="flex flex-col min-h-screen">
      <header className="bg-gray-800 text-white p-4 w-full">
        <nav className="container mx-auto">
          <ul className="flex space-x-4">
            <li>
              <a href="/" className="hover:text-gray-300">
                Home
              </a>
            </li>
            <li>
              <a href="/card-creator" className="hover:text-gray-300">
                Card Creator
              </a>
            </li>
          </ul>
        </nav>
      </header>

      <main className="flex-grow w-full">
        <div className="container mx-auto p-4">
          <Outlet />
        </div>
      </main>

      <footer className="bg-gray-200 p-4 text-center mt-auto w-full">
        <p>&copy; {new Date().getFullYear()} My App</p>
      </footer>
    </div>
  );
}
