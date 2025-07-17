import React from 'react';
import { useAuth } from '../context/AuthContext';

const Home = () => {
    const { isAuthenticated, setIsAuthenticated } = useAuth();

    if (isAuthenticated) {
        return <h2>Bienvenido al sistema</h2>;
    }

    return (
        <div style={{ textAlign: 'center', marginTop: '100px' }}>
            <h1>Bienvenido a AdminArchivos</h1>
            <div style={{ marginTop: '40px' }}>
                <button
                    style={{
                        background: '#d32f2f',
                        color: '#fff',
                        border: 'none',
                        padding: '15px 40px',
                        margin: '0 20px',
                        borderRadius: '8px',
                        fontSize: '1.2rem',
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => {/* lógica para mostrar login */ }}
                >
                    Iniciar sesión
                </button>
                <button
                    style={{
                        background: '#d32f2f',
                        color: '#fff',
                        border: 'none',
                        padding: '15px 40px',
                        margin: '0 20px',
                        borderRadius: '8px',
                        fontSize: '1.2rem',
                        cursor: 'pointer',
                        transition: 'background 0.2s'
                    }}
                    onClick={() => {/* lógica para mostrar registro */ }}
                >
                    Registrarse
                </button>
            </div>
        </div>
    );
};

export default Home;
