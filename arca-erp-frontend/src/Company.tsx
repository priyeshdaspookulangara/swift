import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  TextField,
  Button,
  Box
} from '@mui/material';

interface Company {
  id: number;
  name: string;
  address: string;
  phone: string;
  email: string;
}

const CompanyComponent: React.FC = () => {
  const [companies, setCompanies] = useState<Company[]>([]);
  const [newCompany, setNewCompany] = useState<Omit<Company, 'id'>>({ name: '', address: '', phone: '', email: '' });

  useEffect(() => {
    fetchCompanies();
  }, []);

  const fetchCompanies = async () => {
    try {
      const response = await axios.get<Company[]>('/api/company');
      setCompanies(response.data);
    } catch (error) {
      console.error('Error fetching companies:', error);
    }
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewCompany({ ...newCompany, [event.target.name]: event.target.value });
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    try {
      await axios.post('/api/company', newCompany);
      fetchCompanies();
      setNewCompany({ name: '', address: '', phone: '', email: '' });
    } catch (error) {
      console.error('Error adding company:', error);
    }
  };

  return (
    <Box>
      <h1>Company Management</h1>
      <form onSubmit={handleSubmit}>
        <TextField name="name" label="Name" value={newCompany.name} onChange={handleInputChange} />
        <TextField name="address" label="Address" value={newCompany.address} onChange={handleInputChange} />
        <TextField name="phone" label="Phone" value={newCompany.phone} onChange={handleInputChange} />
        <TextField name="email" label="Email" value={newCompany.email} onChange={handleInputChange} />
        <Button type="submit" variant="contained">Add Company</Button>
      </form>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Address</TableCell>
              <TableCell>Phone</TableCell>
              <TableCell>Email</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {companies.map((company) => (
              <TableRow key={company.id}>
                <TableCell>{company.name}</TableCell>
                <TableCell>{company.address}</TableCell>
                <TableCell>{company.phone}</TableCell>
                <TableCell>{company.email}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default CompanyComponent;
