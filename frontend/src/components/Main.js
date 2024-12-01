function Main(props) {
    return (
        <main className="main">
            <section id="hero" className="hero section dark-background">
                <img src="assets/img/hero-bg.jpg" alt="Hero background" data-aos="fade-in" />
                <div className="container">
                    <div className="row">
                        <div className="col-lg-12">
                            <h2 data-aos="fade-up" data-aos-delay="100">Welcome to Our Website</h2>
                            <p data-aos="fade-up" data-aos-delay="200">We are team of talented designers making websites with Bootstrap</p>
                        </div>
                        <div className="col-lg-12" data-aos="fade-up" data-aos-delay="300" style={{ paddingTop: '20px' }}>
                            <button type="button" class="btn btn-danger">Send Request</button>
                        </div>
                    </div>
                </div>
            </section>

            <section id="about" className="about section light-background">
                {/* About section content remains the same, just fixed className syntax */}
                <div className="container" data-aos="fade-up" data-aos-delay="100">
                    <div className="row align-items-xl-center gy-5">
                        <div className="col-xl-5 content">
                            <h3>About Us</h3>
                            <h2>Ducimus rerum libero reprehenderit cumque</h2>
                            <p>Ipsa sint sit. Quis ducimus tempore dolores impedit et dolor cumque alias maxime. Enim reiciendis minus et rerum hic non. Dicta quas cum quia maiores iure. Quidem nulla qui assumenda incidunt voluptatem tempora deleniti soluta.</p>
                            <a href="#" className="read-more"><span>Read More</span><i className="bi bi-arrow-right"></i></a>
                        </div>

                        <div className="col-xl-7">
                            <div className="row gy-4 icon-boxes">
                                {[
                                    {
                                        icon: "buildings",
                                        title: "Eius provident",
                                        description: "Magni repellendus vel ullam hic officia accusantium ipsa dolor omnis dolor voluptatem"
                                    },
                                    {
                                        icon: "clipboard-pulse",
                                        title: "Rerum aperiam",
                                        description: "Autem saepe animi et aut aspernatur culpa facere. Rerum saepe rerum voluptates quia"
                                    },
                                    {
                                        icon: "command",
                                        title: "Veniam omnis",
                                        description: "Omnis perferendis molestias culpa sed. Recusandae quas possimus. Quod consequatur corrupti"
                                    },
                                    {
                                        icon: "graph-up-arrow",
                                        title: "Delares sapiente",
                                        description: "Sint et dolor voluptas minus possimus nostrum. Reiciendis commodi eligendi omnis quideme lorenda"
                                    }
                                ].map((item, index) => (
                                    <div key={index} className="col-md-6" data-aos="fade-up" data-aos-delay={200 + (index * 100)}>
                                        <div className="icon-box">
                                            <i className={`bi bi-${item.icon}`}></i>
                                            <h3>{item.title}</h3>
                                            <p>{item.description}</p>
                                        </div>
                                    </div>
                                ))}
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section id="stats" className="stats section dark-background">
                <img src="assets/img/stats-bg.jpg" alt="Stats background" data-aos="fade-in" />
                <div className="container position-relative" data-aos="fade-up" data-aos-delay="100">
                    <div className="row gy-4">
                        {[
                            { end: 232, label: "Clients" },
                            { end: 521, label: "Projects" },
                            { end: 1453, label: "Hours Of Support" },
                            { end: 32, label: "Workers" }
                        ].map((stat, index) => (
                            <div key={index} className="col-lg-3 col-md-6">
                                <div className="stats-item text-center w-100 h-100">
                                    <span
                                        data-purecounter-start="0"
                                        data-purecounter-end={stat.end}
                                        data-purecounter-duration="1"
                                        className="purecounter"
                                    ></span>
                                    <p>{stat.label}</p>
                                </div>
                            </div>
                        ))}
                    </div>
                </div>
            </section>

            <section id="faq" className="faq section">
                <div className="container">
                    <div className="row gy-4">
                        <div className="col-lg-4" data-aos="fade-up" data-aos-delay="100">
                            <div className="content px-xl-5">
                                <h3><span>Frequently Asked </span><strong>Questions</strong></h3>
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis aute irure dolor in reprehenderit
                                </p>
                            </div>
                        </div>

                        <div className="col-lg-8" data-aos="fade-up" data-aos-delay="200">
                            <div className="faq-container">
                                {[
                                    {
                                        question: "Non consectetur a erat nam at lectus urna duis?",
                                        answer: "Feugiat pretium nibh ipsum consequat. Tempus iaculis urna id volutpat lacus laoreet non curabitur gravida. Venenatis lectus magna fringilla urna porttitor rhoncus dolor purus non."
                                    },
                                    {
                                        question: "Feugiat scelerisque varius morbi enim nunc faucibus a pellentesque?",
                                        answer: "Dolor sit amet consectetur adipiscing elit pellentesque habitant morbi. Id interdum velit laoreet id donec ultrices. Fringilla phasellus faucibus scelerisque eleifend donec pretium. Est pellentesque elit ullamcorper dignissim. Mauris ultrices eros in cursus turpis massa tincidunt dui."
                                    },
                                    {
                                        question: "Dolor sit amet consectetur adipiscing elit pellentesque?",
                                        answer: "Eleifend mi in nulla posuere sollicitudin aliquam ultrices sagittis orci. Faucibus pulvinar elementum integer enim. Sem nulla pharetra diam sit amet nisl suscipit. Rutrum tellus pellentesque eu tincidunt. Lectus urna duis convallis convallis tellus. Urna molestie at elementum eu facilisis sed odio morbi quis"
                                    },
                                    {
                                        question: "Ac odio tempor orci dapibus. Aliquam eleifend mi in nulla?",
                                        answer: "Dolor sit amet consectetur adipiscing elit pellentesque habitant morbi. Id interdum velit laoreet id donec ultrices. Fringilla phasellus faucibus scelerisque eleifend donec pretium. Est pellentesque elit ullamcorper dignissim. Mauris ultrices eros in cursus turpis massa tincidunt dui."
                                    },
                                    {
                                        question: "Tempus quam pellentesque nec nam aliquam sem et tortor consequat?",
                                        answer: "Molestie a iaculis at erat pellentesque adipiscing commodo. Dignissim suspendisse in est ante in. Nunc vel risus commodo viverra maecenas accumsan. Sit amet nisl suscipit adipiscing bibendum est. Purus gravida quis blandit turpis cursus in"
                                    }
                                ].map((faq, index) => (
                                    <div key={index} className={`faq-item ${index === 0 ? 'faq-active' : ''}`}>
                                        <h3><span className="num">{index + 1}.</span> <span>{faq.question}</span></h3>
                                        <div className="faq-content">
                                            <p>{faq.answer}</p>
                                        </div>
                                        <i className="faq-toggle bi bi-chevron-right"></i>
                                    </div>
                                ))}
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section id="contact" className="contact section">
                <div className="container section-title" data-aos="fade-up">
                    <h2>Contact</h2>
                    <p>Necessitatibus eius consequatur ex aliquid fuga eum quidem sint consectetur velit</p>
                </div>

                <div className="container" data-aos="fade-up" data-aos-delay="100">
                    <div className="row gy-4">
                        <div className="col-lg-6">
                            <div className="row gy-4">
                                {[
                                    {
                                        icon: "geo-alt",
                                        title: "Address",
                                        lines: ["A108 Adam Street", "New York, NY 535022"]
                                    },
                                    {
                                        icon: "telephone",
                                        title: "Call Us",
                                        lines: ["+1 5589 55488 55", "+1 6678 254445 41"]
                                    },
                                    {
                                        icon: "envelope",
                                        title: "Email Us",
                                        lines: ["info@example.com", "contact@example.com"]
                                    },
                                    {
                                        icon: "clock",
                                        title: "Open Hours",
                                        lines: ["Monday - Friday", "9:00AM - 05:00PM"]
                                    }
                                ].map((info, index) => (
                                    <div key={index} className="col-md-6">
                                        <div className="info-item" data-aos="fade" data-aos-delay={200 + (index * 100)}>
                                            <i className={`bi bi-${info.icon}`}></i>
                                            <h3>{info.title}</h3>
                                            {info.lines.map((line, i) => (
                                                <p key={i}>{line}</p>
                                            ))}
                                        </div>
                                    </div>
                                ))}
                            </div>
                        </div>

                        <div className="col-lg-6">
                            <form action="forms/contact.php" method="post" className="php-email-form" data-aos="fade-up" data-aos-delay="200">
                                <div className="row gy-4">
                                    <div className="col-md-6">
                                        <input type="text" name="name" className="form-control" placeholder="Your Name" required />
                                    </div>

                                    <div className="col-md-6">
                                        <input type="email" className="form-control" name="email" placeholder="Your Email" required />
                                    </div>

                                    <div className="col-12">
                                        <input type="text" className="form-control" name="subject" placeholder="Subject" required />
                                    </div>

                                    <div className="col-12">
                                        <textarea className="form-control" name="message" rows="6" placeholder="Message" required></textarea>
                                    </div>

                                    <div className="col-12 text-center">
                                        <div className="loading">Loading</div>
                                        <div className="error-message"></div>
                                        <div className="sent-message">Your message has been sent. Thank you!</div>
                                        <button type="submit">Send Message</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </section>
        </main>
    );
}

export default Main;