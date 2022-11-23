import { Routes, Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Add } from './components/Add';
import { Edit } from './components/Edit';

import './App.css';


function App() {
  return (
    <Routes>
      <Route path="/" element={<Layout />} >
        <Route index path='home' element={<Home />} />
        <Route path='add' element={<Add />} />
        <Route path='edit/:id' element={<Edit />} />
        <Route path='*' element={<Home />} />
      </Route>
    </Routes>
  );
}

export default App;
