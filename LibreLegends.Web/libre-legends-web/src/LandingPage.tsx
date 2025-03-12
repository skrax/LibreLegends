import React from 'react';

const LandingPage = () => {
  return (
    <div className="min-h-screen bg-gray-100">
      <nav className="bg-white shadow">
        <div className="container mx-auto px-4 py-6 flex justify-between items-center">
          <div className="font-bold text-xl text-indigo-600">My Product</div>
          <div className="space-x-4">
            <a href="#features" className="text-gray-600 hover:text-indigo-600">Features</a>
            <a href="#pricing" className="text-gray-600 hover:text-indigo-600">Pricing</a>
            <a href="#contact" className="text-gray-600 hover:text-indigo-600">Contact</a>
            <button className="bg-indigo-600 text-white px-4 py-2 rounded hover:bg-indigo-700">Get Started</button>
          </div>
        </div>
      </nav>

      <header className="bg-gradient-to-r from-indigo-100 to-blue-100 py-20 text-center">
        <div className="container mx-auto px-4">
          <h1 className="text-4xl font-bold text-indigo-800 mb-4">Welcome to My Product</h1>
          <p className="text-lg text-gray-700 mb-8">Your solution for [Problem Your Product Solves].</p>
          <button className="bg-indigo-600 text-white px-8 py-3 rounded-full text-lg hover:bg-indigo-700">Learn More</button>
        </div>
      </header>

      <section id="features" className="py-16">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-3xl font-semibold text-indigo-800 mb-8">Key Features</h2>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
            <div className="p-6 bg-white rounded-lg shadow">
              <h3 className="text-xl font-semibold text-indigo-700 mb-2">Feature 1</h3>
              <p className="text-gray-600">Description of Feature 1.</p>
            </div>
            <div className="p-6 bg-white rounded-lg shadow">
              <h3 className="text-xl font-semibold text-indigo-700 mb-2">Feature 2</h3>
              <p className="text-gray-600">Description of Feature 2.</p>
            </div>
            <div className="p-6 bg-white rounded-lg shadow">
              <h3 className="text-xl font-semibold text-indigo-700 mb-2">Feature 3</h3>
              <p className="text-gray-600">Description of Feature 3.</p>
            </div>
          </div>
        </div>
      </section>

      <section id="pricing" className="bg-gray-50 py-16">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-3xl font-semibold text-indigo-800 mb-8">Pricing</h2>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
            <div className="p-8 bg-white rounded-lg shadow">
              <h3 className="text-2xl font-semibold text-indigo-700 mb-4">Basic</h3>
              <p className="text-4xl font-bold text-indigo-600 mb-4">$19/month</p>
              <ul className="list-disc list-inside text-gray-600 mb-6">
                <li>Feature 1</li>
                <li>Feature 2</li>
                <li>Limited Support</li>
              </ul>
              <button className="bg-indigo-600 text-white px-6 py-3 rounded hover:bg-indigo-700">Choose Plan</button>
            </div>
            <div className="p-8 bg-white rounded-lg shadow">
              <h3 className="text-2xl font-semibold text-indigo-700 mb-4">Pro</h3>
              <p className="text-4xl font-bold text-indigo-600 mb-4">$49/month</p>
              <ul className="list-disc list-inside text-gray-600 mb-6">
                <li>All Basic Features</li>
                <li>Advanced Features</li>
                <li>Priority Support</li>
              </ul>
              <button className="bg-indigo-600 text-white px-6 py-3 rounded hover:bg-indigo-700">Choose Plan</button>
            </div>
            <div className="p-8 bg-white rounded-lg shadow">
              <h3 className="text-2xl font-semibold text-indigo-700 mb-4">Enterprise</h3>
              <p className="text-4xl font-bold text-indigo-600 mb-4">Contact Us</p>
              <ul className="list-disc list-inside text-gray-600 mb-6">
                <li>Custom Solutions</li>
                <li>Dedicated Support</li>
                <li>Scalable Infrastructure</li>
              </ul>
              <button className="bg-indigo-600 text-white px-6 py-3 rounded hover:bg-indigo-700">Contact Us</button>
            </div>
          </div>
        </div>
      </section>

      <section id="contact" className="py-16">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-3xl font-semibold text-indigo-800 mb-8">Contact Us</h2>
          <p className="text-gray-600 mb-8">Have questions? Reach out to us!</p>
          <button className="bg-indigo-600 text-white px-8 py-3 rounded-full text-lg hover:bg-indigo-700">Contact</button>
        </div>
      </section>

      <footer className="bg-gray-800 text-white py-8 text-center">
        <div className="container mx-auto px-4">
          <p>&copy; {new Date().getFullYear()} My Product. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
};

export default LandingPage;