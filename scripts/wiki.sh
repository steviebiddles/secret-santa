#!/bin/sh

cd wiki || exit 1

echo "Init repository in ${PWD}..."

GIT_WIKI_REPOSITORY_URL="https://${PERSONAL_ACCESS_TOKEN}@github.com/steviebiddles/secret-santa.wiki.git"

git init
git add .
git commit -am "publish wiki"
git push --force --set-upstream "$GIT_WIKI_REPOSITORY_URL" master
rm -rf .git
cd ..

echo "Back in project root ${PWD}..."
