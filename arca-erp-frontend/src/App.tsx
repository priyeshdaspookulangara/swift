import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import CompanyComponent from './Company';

const App: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<CompanyComponent />} />
      </Routes>
    </Router>
  );
};

export default App;
