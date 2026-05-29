import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Login from './pages/Login.tsx'
import Dashboard from './pages/Dashboard.tsx'
import Register from './pages/Register.tsx'
import Categories from './pages/Categories.tsx'
import Transactions from './pages/Transactions.tsx'
import Nav from './components/Nav.tsx'
import './App.css'

function App() {
  return (
    <>
        <Router>
          <Nav />
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/" element={<Dashboard />} />

            <Route path="/transactions" element={<Transactions />} />
            <Route path="/categories" element={<Categories />} />

          </Routes>
        </Router>
    </>
  )
}

export default App
