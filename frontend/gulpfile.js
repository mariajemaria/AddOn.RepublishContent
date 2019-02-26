var gulp = require('gulp');
var sass = require('gulp-sass');
var uglify = require('gulp-uglify');
var cssnano = require('gulp-cssnano');
var autoprefixer = require('gulp-autoprefixer');
var browserSync = require('browser-sync').create();
var runSequence = require('run-sequence');

// Path Variables
var SASS__ALL = 'development/scss/**/*.scss';
var CSS__MASTER = 'development/css';

gulp.task('default', () => {
    runSequence(['browserSync'], 'watch')
});

gulp.task('watch', () => {
    gulp.watch('development/scss/**/*.scss', ['sass']);
    gulp.watch('development/*.html', browserSync.reload);
    // gulp.watch('development/js/**/*.js', ['js', browserSync.reload]);
});

gulp.task('browserSync', () => {
    browserSync.init({
        server: {
            baseDir: 'development'
        }
    })
});

// SASS Task
gulp.task('sass', function () {
    return gulp.src(SASS__ALL) // Gets all files ending with .scss in development/scss and children dirs
        .pipe(sass().on('error', sass.logError)) // Passes it through a gulp-sass, log errors to console
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(gulp.dest(CSS__MASTER)) // Outputs it in the css folder
        .pipe(browserSync.reload({ // Reloading with Browser Sync
            stream: true
        }));
})