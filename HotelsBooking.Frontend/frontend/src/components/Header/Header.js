import './Header.css';

const Header = () => {
    return(
        <div className="navbar">
            <div className="navContainer">
                <ul>
                    <li>
                        <a className='logo' href="/Home">FULL STACK BOOKING APP</a>
                    </li>
                </ul>
                <nav className="navItems">

                    <ul>
                        <li><a href="/Register">Register</a></li>
                        /
                        <li><a href="/Login">Login</a></li>
                    </ul>
                </nav>
            </div>
      </div>
    );
}

export default Header