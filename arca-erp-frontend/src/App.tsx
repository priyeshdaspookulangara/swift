import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import CompanyComponent from './Company';
import SalesComponent from './Sales';
import { AppBar, Toolbar, Typography, Button } from '@mui/material';

const App: React.FC = () => {
  return (
    <Router>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            ARCA ERP
          </Typography>
          <Button color="inherit" component={Link} to="/">Company</Button>
          <Button color="inherit" component={Link} to="/sales">Sales</Button>
        </Toolbar>
      </AppBar>
      <Routes>
        <Route path="/" element={<CompanyComponent />} />
        <Route path="/sales" element={<SalesComponent />} />
      </Routes>
    </Router>
  );
};

export default App;
