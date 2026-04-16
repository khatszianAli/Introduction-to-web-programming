<head>
    <style>
        .about {
    display: flex;
    margin-top: 25px;
    padding: 0 60px; /* Figma: Frame 41 padding Left/Right = 60px */
    width: 100%;
    gap: 40px; /* Figma: Frame 41 Gap = 40px */
    flex-wrap: wrap;
}

.about_part {
    display: flex;
    width: 100%;
    gap: 16px; /* Figma: Frame 63 Gap = 16px */
    flex-wrap: wrap;
}

.about_title, .sub_title {
    width: 100%; /* Figma: Fill 1320px → 100% */
    color: #FFFFFF; /* Figma: #FFFFFF */
    font-family: "Unbounded";
    font-weight: 700; /* Figma: Bold */
    font-size: 28px; /* Figma: 28px (не 1.1rem) */
    line-height: 100%;
    margin-bottom: 0; /* gap управляет отступами */
}

.content {
    display: flex;
    width: 100%;
    gap: 10px;
    flex-wrap: wrap;
}

.members .content {
    flex-wrap: nowrap;
    gap: 16px;
}

.reason .content {
    flex-direction: row;
    flex-wrap: nowrap;
    gap: 20px;
    align-items: flex-start;
}

.desc {
    width: 100%;
    color: #FFFFFF; /* Figma: #FFFFFF */
    font-family: "Montserrat";
    font-weight: 400; /* Figma: Regular */
    font-size: 16px; /* Figma: 16px (не 0.7rem = ~11px) */
    line-height: 150%; /* Figma: 150% */
    word-break: break-word;
}

.img_about {
    width: 100%;
    height: 252px;
    object-fit: cover;
    border-radius: 24px;
}

.mission {
    display: flex;
    width: 100%;
    flex-direction: column;
    gap: 16px;
}

.mission .content {
    display: flex;
    flex-direction: row;
    align-items: flex-start;
    gap: 20px;
    flex-wrap: nowrap;
}

.img_mission {
    width: 460px;
    height: 144px;
    object-fit: cover;
    border-radius: 24px;
}

.member {
    display: flex;
    flex-direction: column;
    flex: 1 1 0;
    min-width: 0;
    border: 1px solid transparent;
    border-radius: 24px;
    background-image: linear-gradient(#0C111C, #0C111C),
        linear-gradient(to left top, #0D99FF, #CA2C66);
    background-origin: border-box;
    background-clip: padding-box, border-box;
    transition: all 0.1s;
}

.member:hover {
    color: #0D99FF;
    border: 1px solid rgba(13, 153, 255);
}

.img_memb {
    object-fit: cover;
    border-radius: 24px;
    width: 100%;
    height: 281px;
}

.memb_text {
    display: flex;
    flex-direction: column;
    height: 100%;
    border-radius: 24px;
    padding: 1rem;
    gap: 8px;
    word-break: break-word;
}

.name {
    color: white;
    width: 100%;
    font-family: "Montserrat";
    font-weight: 600;
    font-size: 0.9rem;
    line-height: 1.5;
}

.memb_desc {
    color: #A9A9A9;
    width: 100%;
    font-family: "Montserrat";
    font-weight: 500;
    font-size: 0.57rem;
    line-height: 140%;
}

.img_reason {
    width: 460px;
    height: 288px;
    object-fit: cover;
    border-radius: 24px;
}

.achieve_content {
    width: 100%;
    display: flex;
    flex-direction: column;
    gap: 15px;
}

.achieve_tab {
    display: flex;
    flex-direction: column;
    color: white;
    width: 100%;
    padding: 1.1rem;
    gap: 10px;
    font-family: "Montserrat";
    border: 1px solid transparent;
    border-radius: 20px;
    background-image: linear-gradient(#0C111C, #0C111C),
        linear-gradient(to right bottom, #0D99FF, #CA2C66);
    background-origin: border-box;
    background-clip: padding-box, border-box;
    transition: all 0.1s;
}

.achieve_tab:hover {
    background-image: linear-gradient(#0D99FF, #0D99FF),
        linear-gradient(to right bottom, #0D99FF, #0D99FF);
    border: 1px solid rgb(13, 153, 255);
}

.achieve_text {
    width: 100%;
    font-weight: 600;
    font-size: 1rem;
    line-height: 1.5;
}

.year {
    width: 100%;
    font-weight: 300;
    font-size: 0.7rem;
    line-height: 100%;
}

p {
    margin-block-end: 0;
}

/* КАРУСЕЛЬ */
.gallery {
    width: 100%;
    position: relative;
}

.gallery-container {
    position: relative;
    max-width: 100%;
    margin: 0 auto;
}

.carousel {
    width: 100%;
    height: 350px;
    overflow: hidden;
    border-radius: 20px;
    position: relative;
}

.carousel-track {
    display: flex;
    transition: transform 0.5s ease-in-out;
    height: 100%;
}

.glr_card {
    flex: 0 0 100%;
    height: 350px;
    width: 100%;
    border-radius: 20px;
    object-fit: cover;
    display: block;
}

.carousel-btn {
    position: absolute;
    top: 92%;
    width: 3rem;
    height: 3rem;
    border-radius: 50%;
    border: none;
    background: #CA2C66;
    color: #fff;
    font-size: 1.5rem;
    cursor: pointer;
    z-index: 10;
    display: flex;
    align-items: center;
    justify-content: center;
    transition: background-color 0.2s;
}

.carousel-btn:hover {
    background: #0D99FF;
}

.carousel-btn--prev {
    left: 10px;
    transform: translateX(20vw);
}

.carousel-btn--next {
    right: 10px;
    transform: translateX(-20vw);
}

.dots {
    display: flex;
    justify-content: center;
    margin-top: 30px;
    gap: 10px;
}

.dot {
    width: 12px;
    height: 12px;
    background: #0D99FF;
    border-radius: 50%;
    opacity: 0.5;
    cursor: pointer;
    transition: 0.2s;
}

.dot.active {
    background: #CA2C66;
    opacity: 1;
    transform: scale(1.3);
}

/* =========================
         ADAPTIVE
   ========================= */

@media (max-width: 1200px) {
    .about {
        padding: 0 40px;
    }
}

@media (max-width: 900px) {
    .about {
        padding: 0 24px;
        justify-content: center;
    }

    .mission .content,
    .reason .content {
        flex-direction: column;
    }

    .members .content {
        flex-wrap: wrap;
    }

    .member {
        flex: 1 1 calc(50% - 8px);
    }

    .img_mission,
    .img_reason {
        width: 100%;
    }
}

@media (max-width: 600px) {
    .about {
        padding: 0 16px;
    }

    .carousel {
        height: 260px;
    }

    .glr_card {
        height: 260px;
    }
}

@media (max-width: 480px) {
    .about {
        padding: 0 12px;
    }
}
    </style>
</head>

<body>
    {% assign about = Model.ContentItem.Content %}

    <div class="about">
        <section class="about_part">
            <div class="about_title">О нас</div>

            <div class="desc">
                {{ about.FlowPart.Widgets[0].Paragraph.Content.Html | raw }}
            </div>

            <img class="img_about" src={{ about.Page.Images.Paths[0] | asset_url }} alt="Image">

            <div class="desc">
                {{ about.FlowPart.Widgets[1].Paragraph.Content.Html | raw }}
            </div>
        </section>

        <section class="mission">
            <div class="sub_title">
                {{ about.FlowPart.Widgets[2].Paragraph.Content.Html | raw }}
            </div>

            <div class="content">
                <img class="img_mission" src={{ about.Page.Images.Paths[1] | asset_url }} alt="Image" />

                <div class="desc">
                    {{ about.FlowPart.Widgets[3].Paragraph.Content.Html | raw }}
                </div>
            </div>
        </section>

        <section class="members">
            <div class="sub_title">
                {{ about.FlowPart.Widgets[4].Paragraph.Content.Html | raw }}
            </div>

            {% assign team = about.FlowPart.Widgets[5].FlowPart.Widgets %}

            <div class="content">
                {% for memb in team %}
                    <div class="member">
                        <img class="img_memb" src="{{ memb.MemberWidget.Image.Paths[0] | asset_url }}" alt="{{ memb.ContentItem | DisplayText }}">

                        <div class="memb_text">
                            <div class="name">{{ memb.DisplayText }}</div>
                            <div class="memb_desc">{{ memb.MarkdownBodyPart.Markdown }}</div>
                        </div>
                    </div>
                {% endfor %}
            </div>
        </section>

        <section class="reason">
            <div class="sub_title">
                {{ about.FlowPart.Widgets[6].Paragraph.Content.Html | raw }}
            </div>

            <div class="content">
                <div class="desc">
                    {{ about.FlowPart.Widgets[7].Paragraph.Content.Html | raw }}
                </div>

                <img class="img_reason" src={{ about.Page.Images.Paths[2] | asset_url }} alt="Image" />
            </div>
        </section>

        <section class="achievements">
            <div class="sub_title">
                {{ about.FlowPart.Widgets[8].Paragraph.Content.Html | raw }}
            </div>

            {% assign list = about.FlowPart.Widgets[9].FlowPart.Widgets %}

            <div class="achieve_content">
                {% for achieve in list %}
                    <div class="achieve_tab">
                        <div class="achieve_text">{{ achieve.MarkdownBodyPart.Markdown }}</div>
                        <div class="year">{{ achieve.AchievementWidget.Year.Text }}</div>
                    </div>
                {% endfor %}
            </div>
        </section>

        <section class="gallery">
            <div class="sub_title">
                {{ about.FlowPart.Widgets[10].Paragraph.Content.Html | raw }}
            </div>

            {% assign images = about.FlowPart.Widgets[11].FlowPart.Widgets %}
            
            <div class="gallery-container">
                <button class="carousel-btn carousel-btn--prev">←</button>
                <button class="carousel-btn carousel-btn--next">→</button>

                <div class="carousel">
                    <div class="carousel-track">
                        {% for card in images %}
                            <img class="glr_card" src="{{ card.Image.Media.Paths[0] | asset_url }}" alt="Image" />
                        {% endfor %}
                    </div>
                </div>

                <div class="dots"></div>
            </div>
        </section>
    </div>

    <script>
        document.addEventListener('DOMContentLoaded', function() {
            const carousel = document.querySelector('.carousel');
            const carouselTrack = document.querySelector('.carousel-track');
            const slides = [...document.querySelectorAll('.glr_card')];
            const btnNext = document.querySelector('.carousel-btn--next');
            const btnPrev = document.querySelector('.carousel-btn--prev');
            const dotsContainer = document.querySelector('.dots');

            if (slides.length === 0) return;

            let currentIndex = 0;
            const totalSlides = slides.length;

            // Создаём точки
            slides.forEach((_, i) => {
                const dot = document.createElement("div");
                dot.className = "dot";
                dot.dataset.index = i;
                dotsContainer.appendChild(dot);
                dot.addEventListener('click', () => goToSlide(i));
            });

            const dots = [...document.querySelectorAll('.dot')];
            updateDots();

            // Функция для перехода к конкретному слайду
            function goToSlide(index) {
                currentIndex = index;
                updateCarousel();
                updateDots();
            }

            // Функция для обновления позиции карусели
            function updateCarousel() {
                const slideWidth = carousel.clientWidth; // Используем ширину контейнера
                const offset = -currentIndex * slideWidth;
                carouselTrack.style.transform = `translateX(${offset}px)`;
            }

            // Функция для обновления активной точки
            function updateDots() {
                dots.forEach((dot, index) => {
                    dot.classList.toggle('active', index === currentIndex);
                });
            }

            // Следующий слайд (с циклическим переходом)
            function nextSlide() {
                currentIndex = (currentIndex + 1) % totalSlides;
                updateCarousel();
                updateDots();
            }

            // Предыдущий слайд (с циклическим переходом)
            function prevSlide() {
                currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
                updateCarousel();
                updateDots();
            }

            // Обработчики кнопок
            btnNext.addEventListener('click', nextSlide);
            btnPrev.addEventListener('click', prevSlide);

            // Автоматическое переключение (опционально, раскомментируйте если нужно)
            // let autoplay = setInterval(nextSlide, 5000);
            
            // Останавливаем автоплей при наведении
            // carousel.addEventListener('mouseenter', () => clearInterval(autoplay));
            // carousel.addEventListener('mouseleave', () => {
            //     autoplay = setInterval(nextSlide, 5000);
            // });

            // Адаптация к изменению размера окна
            let resizeTimeout;
            window.addEventListener('resize', () => {
                clearTimeout(resizeTimeout);
                resizeTimeout = setTimeout(() => {
                    updateCarousel();
                }, 250);
            });

            // Инициализация при загрузке
            updateCarousel();
        });
    </script>
</body>