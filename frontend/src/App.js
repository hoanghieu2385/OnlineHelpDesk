import {Route, Routes} from 'react-router-dom'
import path from './utils/path'
import { Home, Public, } from './pages/index'

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path={path.PUBLIC} element={<Public />}>
          <Route index element={<Home />} />
          {/* <Route path={path.CREATE} element={<Create />} />
          <Route path={path.EDIT} element={<Edit />} /> */}
        </Route>  
      </Routes>
    </div>
  );
}

export default App;
