#!/bin/sh

cd wiki || exit 1

echo "Init repository in ${PWD}..."

git init
git add .
git commit -am "publish wiki"
git push --force https://github.com/steviebiddles/secret-santa.wiki.git master
rm -rf .git
cd ..

echo "Back in project root ${PWD}..."
