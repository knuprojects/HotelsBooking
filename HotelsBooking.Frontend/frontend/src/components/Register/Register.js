import './Register.css';

const Register = () => {
    return(
        <div className="center">
            <h1>Register</h1>
            <form method="post">
                <div className="txt_field">
                    <input type="text" required/>
                    <span></span>
                    <label>Login</label>
                </div>
                <div className="txt_field">
                    <input type="text" required/>
                    <span></span>
                    <label>Email</label>
                </div>
                <div className="txt_field">
                    <input type="password" required/>
                    <span></span>
                    <label>Password</label>
                </div>
                <input type="submit" value="Register"/>
            </form>
        </div>
    );
}

export default Register