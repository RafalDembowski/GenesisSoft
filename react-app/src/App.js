import './App.css';
import 'rsuite/dist/rsuite.min.css';
import ProductList from './components/products/ProductList';
import { store, StoreContext } from './stores/store';

function App() {

  return (
    <StoreContext.Provider value={store}>
      <ProductList />
    </StoreContext.Provider>
  );
}

export default App;
