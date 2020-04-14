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
git rm -r --cached Assets/Sounds/
git-lfs track Assets/Sounds/**
git add Assets/Sounds/
git commit
```
Verfiy they are tracked with: `git-lfs ls-files`.

### Github Pages
We use Github Pages to track important notes and documentation for programming:
[Documentation](https://ink-inc.github.io/MagicMittelalterGame/)
