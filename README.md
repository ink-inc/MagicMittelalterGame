**Edit a file, create a new file, and clone from Bitbucket in under 2 minutes**

When you're done, you can delete the content in this README and update the file with details for others getting started with your repository.

*We recommend that you open this README in another tab as you perform the tasks below. You can [watch our video](https://youtu.be/0ocf7u76WSo) for a full demo of all the steps in this tutorial. Open the video in a new tab to avoid leaving Bitbucket.*

---

## Edit a file

You’ll start by editing this README file to learn how to edit a file in Bitbucket.

1. Click **Source** on the left side.
2. Click the README.md link from the list of files.
3. Click the **Edit** button.
4. Delete the following text: *Delete this line to make a change to the README from Bitbucket.*
5. After making your change, click **Commit** and then **Commit** again in the dialog. The commit page will open and you’ll see the change you just made.
6. Go back to the **Source** page.

---

## Create a file

Next, you’ll add a new file to this repository.

1. Click the **New file** button at the top of the **Source** page.
2. Give the file a filename of **contributors.txt**.
3. Enter your name in the empty file space.
4. Click **Commit** and then **Commit** again in the dialog.
5. Go back to the **Source** page.

Before you move on, go ahead and explore the repository. You've already seen the **Source** page, but check out the **Commits**, **Branches**, and **Settings** pages.

---

## Clone a repository

Use these steps to clone from Github. Cloning allows you to work on your files locally. This projekt uses large files meaning
you need to install [git lfs](https://github.com/git-lfs/git-lfs/wiki/Installation).

1. You’ll see the clone button under the **Clone or download** heading. Click that button.
2. Copy the link.
3. Open your Comand Line Tool of your choice.
4. Navigate to the destination folder.
5. Enter `git clone <copied link>`. 

If you installed `git lfs` after cloning the project `git lfs fetch` can work, but in most cases you have to delete the local project and re-clone it again.

## Adding large files

Large files should be tracked by lfs. This can be done with
```console
git-lfs track <file>
```
You could use all sorts of regrex expressions here. For example
```console
git-lfs track Assets/Sounds/**  # tracks everything in the sound directory
git-lfs track '*.bin'           # tracks every bin file
```

### LFS track after check-in

If you already commit large files and forgot to track them. No worries! This simple trick should do it. This is an exmple for the directory `Sounds` in `Assets` but it should work with all other regrex expressions.

```console
git rm -r Assets/Sounds/
git-lfs track Assets/Sounds/**
git add Assets/Sounds/
git commit
```
Verfiy they are tracked with: `git-lfs ls-files`.
