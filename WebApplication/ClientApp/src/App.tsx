import React from 'react';
import { Route } from 'react-router';
import Championship from './components/Championship';
import Home from './components/Home';
import Layout from './components/Layout';

function App() {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/classify' component={Championship} />
    </Layout>
  );
}

export default App;
