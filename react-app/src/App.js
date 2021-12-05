import './App.css';
import 'rsuite/dist/rsuite.min.css';
import ProductDetails from './components/products/ProductDetails';
import ProductList from './components/products/ProductList';
import { store, StoreContext } from './stores/store';
import { BrowserRouter as Router, Routes ,Route } from 'react-router-dom';

function App() {

  return (
    <StoreContext.Provider value={store}>
      <Router>
        <Routes>
          <Route path="products" element={<ProductList />}/>
          <Route path="products/:id" element={<ProductDetails />}/>
        </Routes>
      </Router>
    </StoreContext.Provider>
  );
}

export default App;

