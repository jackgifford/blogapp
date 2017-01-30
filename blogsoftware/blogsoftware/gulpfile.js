var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var sass = require('gulp-sass');
var cssmin = require('gulp-cssmin');
var rename = require('gulp-rename');

var paths = {
    sass: "Content/scss/",
    output: "Content/css/"
};


gulp.task("sass:compile", function () {
    return gulp.src(paths.sass + "main.scss")
        .pipe(sass())
        .pipe(gulp.dest(paths.sass));
});

gulp.task("bundle:css", ["sass:compile"], function () {
    return gulp.src(paths.sass + "main.css")
		.pipe(concat("styles.css"))
		.pipe(gulp.dest(paths.output))
		.pipe(rename({ suffix: ".min" }))
		.pipe(cssmin())
		.pipe(gulp.dest(paths.output));
});

gulp.task("watch", function () {
    gulp.watch(paths.sass + "**/*.scss", ["bundle:css"]);
});

