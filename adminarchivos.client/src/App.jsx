import React from 'react';
import Sidebar from './components/Sidebar';
import Home from './pages/Home';
import { useAuth, AuthProvider } from './context/AuthContext';

function MainLayout() {
    const { isAuthenticated } = useAuth();

    return (
        <div>
            {isAuthenticated && <Sidebar />}
            <div style={{ marginLeft: isAuthenticated ? '220px' : '0', padding: '40px' }}>
                <Home />
                {/* Aquí irán las rutas */}
            </div>
        </div>
    );
}

function App() {
    return (
        <AuthProvider>
            <MainLayout />
        </AuthProvider>
    );
}

export default App;
