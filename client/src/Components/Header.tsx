import styles from "./Header.module.css";
import React from "react";

type HeaderProps = React.ComponentPropsWithoutRef<"header">;

function Header(props: HeaderProps) {
  return (
    <header {...props} className={styles.header}>
      <h2>The GameStore</h2>
    </header>
  );
}

export default Header;
