import React, { useState } from 'react';
import './Sidebar.css'; 

const Sidebar = ({ children }) => {
    const [isHovered, setIsHovered] = useState(false);

    return (
        <div
            className={`sidebar${isHovered ? ' hovered' : ''}`}
            onMouseEnter={() => setIsHovered(true)}
            onMouseLeave={() => setIsHovered(false)}
        >
            <nav>
                <ul>
                    <li><a href="/">Home</a></li>
                    <li><a href="/registro">Registro</a></li>
                    <li><a href="/login">Inicio de sesión</a></li>
                </ul>
            </nav>
            {children}
        </div>
    );
};

export default Sidebar;
