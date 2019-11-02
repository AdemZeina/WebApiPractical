import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';


import FetchData from './components/FetchData';

export default () => (
  <Layout> 
  <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </Layout>
);
