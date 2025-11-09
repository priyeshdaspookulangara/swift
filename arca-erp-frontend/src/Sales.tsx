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

interface Item {
  id: number;
  name: string;
}

interface Customer {
  id: number;
  name: string;
}

interface SalesOrderItem {
  itemId: number;
  item?: Item;
  quantity: number;
  unitPrice: number;
}

interface SalesOrder {
  id: number;
  orderDate: string;
  customerId: number;
  customer?: Customer;
  items: SalesOrderItem[];
  totalAmount: number;
}

const SalesComponent: React.FC = () => {
  const [salesOrders, setSalesOrders] = useState<SalesOrder[]>([]);
  const [newSalesOrder, setNewSalesOrder] = useState<Omit<SalesOrder, 'id'>>({
    orderDate: new Date().toISOString().slice(0, 10),
    customerId: 0,
    items: [],
    totalAmount: 0
  });

  useEffect(() => {
    fetchSalesOrders();
  }, []);

  const fetchSalesOrders = async () => {
    try {
      const response = await axios.get<SalesOrder[]>('/api/sales');
      setSalesOrders(response.data);
    } catch (error) {
      console.error('Error fetching sales orders:', error);
    }
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewSalesOrder({ ...newSalesOrder, [event.target.name]: event.target.value });
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    try {
      await axios.post('/api/sales', newSalesOrder);
      fetchSalesOrders();
      setNewSalesOrder({
        orderDate: new Date().toISOString().slice(0, 10),
        customerId: 0,
        items: [],
        totalAmount: 0
      });
    } catch (error) {
      console.error('Error adding sales order:', error);
    }
  };

  return (
    <Box>
      <h1>Sales Management</h1>
      <form onSubmit={handleSubmit}>
        <TextField name="orderDate" label="Order Date" type="date" value={newSalesOrder.orderDate} onChange={handleInputChange} InputLabelProps={{ shrink: true }} />
        <TextField name="customerId" label="Customer ID" type="number" value={newSalesOrder.customerId} onChange={handleInputChange} />
        <Button type="submit" variant="contained">Add Sales Order</Button>
      </form>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Order Date</TableCell>
              <TableCell>Customer</TableCell>
              <TableCell>Total Amount</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {salesOrders.map((salesOrder) => (
              <TableRow key={salesOrder.id}>
                <TableCell>{new Date(salesOrder.orderDate).toLocaleDateString()}</TableCell>
                <TableCell>{salesOrder.customer?.name}</TableCell>
                <TableCell>{salesOrder.totalAmount}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
};

export default SalesComponent;
