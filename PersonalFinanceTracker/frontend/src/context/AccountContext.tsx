import { createContext, useEffect, useState } from "react";

export const AccountContext = createContext(null);

export function AccountContextProvider({ children }) {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    const fullName = localStorage.getItem("fullName");

    if (token) {
      setUser({ token, fullName });
    }
  }, []);

  const login = (data) => {
    localStorage.setItem("token", data.token);
    localStorage.setItem("fullName", data.fullName);

    setUser({
      token: data.token,
      fullName: data.fullName,
    });
  };

  const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("fullName");
    setUser(null);
  };

  return (
    <AccountContext.Provider value={{ user, login, logout }}>
      {children}
    </AccountContext.Provider>
  );
}