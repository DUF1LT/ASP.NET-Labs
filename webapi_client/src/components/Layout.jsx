import { Link, Outlet } from "react-router-dom";

export function Layout() {
    return (
        <>
            <header className='App-header'>
                <Link className='App-link' to='home'>
                    Home
                </Link>
                <Link className='App-link' to='add'>
                    Add
                </Link>
            </header>
            <main className='main'>
                <Outlet />
            </main>
        </>
    );
}