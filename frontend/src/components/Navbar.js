import React from 'react';

export default function Navbar() {
    return (
        <header id="header" className="header d-flex align-items-center fixed-top">
            <div className="container-fluid position-relative d-flex align-items-center justify-content-between">

                <a href="index.html" className="logo d-flex align-items-center me-auto me-xl-0">

                    <img src="assets/img/logo.png" alt="" />
                    <h1 className="sitename">Online Help Desk</h1><span>.</span>
                </a>

                <nav id="navmenu" className="navmenu">
                    <ul>
                        <li><a href="index.html#hero" className="active">Home</a></li>
                        <li><a href="index.html#about">About</a></li>
                        <li>
                            {/* <Link to="/send-request">Send Request</Link> */}
                        </li>
                        <li><a href="index.html#portfolio">Portfolio</a></li>
                        <li><a href="index.html#pricing">Pricing</a></li>
                        <li><a href="index.html#team">Team</a></li>
                        <li><a href="blog.html">Blog</a></li>
                        <li className="dropdown"><a href="#"><span>Dropdown</span> <i className="bi bi-chevron-down toggle-dropdown"></i></a>
                            <ul>
                                <li><a href="#">Dropdown 1</a></li>
                                <li className="dropdown"><a href="#"><span>Deep Dropdown</span> <i className="bi bi-chevron-down toggle-dropdown"></i></a>
                                    <ul>
                                        <li><a href="#">Deep Dropdown 1</a></li>
                                        <li><a href="#">Deep Dropdown 2</a></li>
                                        <li><a href="#">Deep Dropdown 3</a></li>
                                        <li><a href="#">Deep Dropdown 4</a></li>
                                        <li><a href="#">Deep Dropdown 5</a></li>
                                    </ul>
                                </li>
                                <li><a href="#">Dropdown 2</a></li>
                                <li><a href="#">Dropdown 3</a></li>
                                <li><a href="#">Dropdown 4</a></li>
                            </ul>
                        </li>
                        <li><a href="index.html#contact">Contact</a></li>
                    </ul>
                    <i className="mobile-nav-toggle d-xl-none bi bi-list"></i>
                </nav>

                <a className="btn-getstarted" href="index.html#about">Sign in</a>

            </div>
        </header>
    );
}
